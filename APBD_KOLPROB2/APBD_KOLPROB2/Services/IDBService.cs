using APBD_KOLPROB2.DTO;
using APBD_KOLPROB2.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APBD_KOLPROB2.Services
{
    public interface IDBService
    {
        Task<IList<ActionDTO>> GetActionByIdAsync(int IdAction);
        Task<Response> AddFireTruckToAction(AddFireTruckToActionDTO fireTruckToActionDTO);
    }
}
