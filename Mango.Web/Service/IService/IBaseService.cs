using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
       
        Task<ResponseDto?> SendAsync<T>(RequestDto requestDto);
    }
}
