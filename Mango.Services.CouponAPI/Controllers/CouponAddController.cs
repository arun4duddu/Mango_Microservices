using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAddController : ControllerBase
    {
        
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        private IMapper _mapper; 
        public CouponAddController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto GetCoupons()
        {
            try
            {
                IEnumerable<Coupon> objlist = _db.Coupons.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(objlist);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;

            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetCoupons(int id)
        {
            try
            {
                Coupon objlist = _db.Coupons.First(x=>x.CouponId == id);

                _responseDto.Result = _mapper.Map<Coupon>(objlist);
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByCode{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon objlist = _db.Coupons.FirstOrDefault(x => x.CouponCode == code);

                _responseDto.Result = _mapper.Map<Coupon>(objlist);
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpPost]
         public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon objcoup = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(objcoup);
                _db.SaveChanges();
                _responseDto.Result = _mapper.Map<CouponDto>(objcoup);
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon objcoup = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(objcoup);
                _db.SaveChanges();
                _responseDto.Result = _mapper.Map<CouponDto>(objcoup);
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon objcoup =  _db.Coupons.First(u=>u.CouponId == id);
                _db.Coupons.Remove(objcoup);
                _db.SaveChanges();
                _responseDto.Result = _mapper.Map<CouponDto>(objcoup);
            }
            catch (Exception ex)
            {

                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
