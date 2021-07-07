using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livescore.Data.Abstract;
using Livescore.Entity;
using Microsoft.EntityFrameworkCore;

namespace Livescore.Data.Concreate.EfCore
{
    public class EfCoreMatchRepository : IMatchRepository
    {
        public static async Task<bool> ControlMatchDetails(Match match)
        {
            await using (var context = new LiveScoreContext())
            {
                //var controlMatch = context.Set<Match>().First(m => m.Id == match.Id);
                var controlMatch = context.Set<Match>().FirstOrDefault(x => x.Id == match.Id);

                //Eğer databasede ilgili maç yoksa
                if (controlMatch == null)
                {
                    try
                    {
                        var controlHt = context.Set<Team>().AsNoTracking().FirstOrDefault(ht => ht.Id == match.HomeTeam.Id);
                        //Maçın ev sahibi takımı DB'de yoksa ekle
                        if (controlHt == null)
                        {
                            context.Set<Team>().Add(match.HomeTeam);
                        }

                        var controlAt = context.Set<Team>().AsNoTracking().FirstOrDefault(at => at.Id == match.AwayTeam.Id);
                        //Maçın deplasman takımı DB'de yoksa ekle
                        if (controlAt == null)
                        {
                            context.Set<Team>().Add(match.AwayTeam);
                        }

                        var controlRound = context.Set<Round>().AsNoTracking().FirstOrDefault(r => r.Id == match.Round.Id);
                        //Maçın Round'u db'de yoksa ekle
                        if (controlRound == null)
                        {
                            context.Set<Round>().Add(match.Round);
                        }

                        var controlStage = context.Set<Stage>().AsNoTracking().FirstOrDefault(s => s.Id == match.Stage.Id);
                        //Maçın stagei db'de yoksa ekle
                        if (controlStage == null)
                        {
                            context.Set<Stage>().Add(match.Stage);
                        }

                        var controlStatus = context.Set<Status>().AsNoTracking().FirstOrDefault(st => st.Id == match.Status.Id);
                        //Maçın statusu db'de yoksa ekle
                        if (controlStatus == null)
                        {
                            context.Set<Status>().Add(match.Status);
                        }

                        //Maçı db'ye ekle
                        await context.Set<Match>().AddAsync(match);
                        await context.SaveChangesAsync();

                    }
                    // TODO log exception
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                    return false;
                }
                else
                {
                    //maçın statüsü != full time, bilgilerini güncelle
                    if (match.Status.Id != 5)
                    {
                        //Maçın timeını update et
                        context.Entry(match.Times).State = EntityState.Modified;
                        await context.SaveChangesAsync();

                        //Takımların skorunu update et
                        if (match.HomeTeam.Score != null && match.AwayTeam.Score != null)
                        {
                            context.Entry(match.HomeTeam.Score).State = EntityState.Modified;
                            context.Entry(match.AwayTeam.Score).State = EntityState.Modified;
                            await context.SaveChangesAsync();
                        }
                    }

                    //match.SystemUpdateDate = DateTime.Now;
                    //context.Entry(match).State = EntityState.Modified;
                    //await context.SaveChangesAsync();
                    return true;
                }
            }
        }

        Task<bool> IMatchRepository.ControlMatchDetails(Match match)
        {
            return ControlMatchDetails(match);
        }

        public async Task<List<Match>> TodaysMatches()
        {
            await using (var context = new LiveScoreContext())
            {
                return await context.Set<Match>().OrderByDescending(c=>c.Date).ToListAsync();
            }
        }
    }
}
