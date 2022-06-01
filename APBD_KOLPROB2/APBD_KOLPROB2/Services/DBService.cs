using APBD_KOLPROB2.Data;
using APBD_KOLPROB2.DTO;
using APBD_KOLPROB2.Responses;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using APBD_KOLPROB2.Entities;

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
            IList<ActionDTO> list = await _context.Actions
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
            return list;
        }
        public async Task<Response> AddFireTruckToAction(AddFireTruckToActionDTO fireTruckToActionDTO)
        {

            Response response = new();

            var actionFromDB = await _context.Actions.SingleOrDefaultAsync(e => e.IdAction == fireTruckToActionDTO.IdAction);
            var firetruckFromDB = await _context.FireTrucks.SingleOrDefaultAsync(e => e.IdFireTruck == fireTruckToActionDTO.IdFireTruck);

            if(actionFromDB == null || firetruckFromDB == null)
            {
                response.Message = "Something does not exist in DB";
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }

            if (await _context.FireTruckActions
                .Where(e => e.IdAction == fireTruckToActionDTO.IdAction)
                .CountAsync() >= 3)
            {
                response.Message = "Max 3 firetrucks";
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            //Other checks:
            //is this firetruck already assigned to this action?
            //does this action require special equip

            await _context.FireTruckActions.AddAsync(new FireTruckAction
            {
                IdAction = actionFromDB.IdAction,
                IdFireTruck = firetruckFromDB.IdFireTruck,
                AssignmentDate = System.DateTime.Now
            });

            await _context.SaveChangesAsync();
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "Ok";
            return response;

        }
    }
}
