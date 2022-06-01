using APBD_KOLPROB2.Data;
using APBD_KOLPROB2.DTO;
using APBD_KOLPROB2.Responses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_KOLPROB2.Services
{
    public class DBService : IDBService
    {
        private readonly FireTruckStationContext _context;
        public DBService(FireTruckStationContext context)
        {
            _context = context;
        }
        public async Task<IList<ActionDTO>> GetActionByIdAsync(int IdAction)
        {
            return await _context.Actions
                .Where(e => e.IdAction == IdAction)
                .Include(e => e.FireTruckActions)
                .ThenInclude(f => f.IdFireTruckNavigation)
                .Select(e => new ActionDTO
                {
                    IdAction = e.IdAction,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    NeedSpecialEquipment = e.NeedSpecialEquipment,
                    Firetrucks = e.FireTruckActions
                                    .OrderByDescending(f => f.AssignmentDate)
                                    .Select(f => new FireTruckDTO
                                    {
                                        IdFiretruck = f.IdFireTruck,
                                        OperationNumber = f.IdFireTruckNavigation.OperationNumber,
                                        SpecialEquipment = f.IdFireTruckNavigation.SpecialEquipment
                                    })
                }).ToListAsync();
        }
    }
}
