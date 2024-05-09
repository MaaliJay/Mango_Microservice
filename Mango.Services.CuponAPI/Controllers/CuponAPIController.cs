using AutoMapper;
using Mango.Services.CuponAPI.Data;
using Mango.Services.CuponAPI.Models;
using Mango.Services.CuponAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CuponAPI.Controllers
{
    [Route("api/cupon")]
    [ApiController]
    public class CuponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private ResponseCuponDTO _response;

        public CuponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseCuponDTO();
        }

        [HttpGet]
        public ResponseCuponDTO Get()
        {
            try
            {

                IEnumerable<Cupon> objectList = _db.Cupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CuponDTO>>(objectList);

            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseCuponDTO GetById(int id)
        {
            try
            {

                Cupon objectList = _db.Cupons.First(x => x.CuponId == id);
                _response.Result = _mapper.Map<CuponDTO>(objectList);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseCuponDTO GetByCode(string code)
        {
            try
            {

                Cupon objectList = _db.Cupons.FirstOrDefault(x => x.CuponCode.ToLower() == code.ToLower());
                if(objectList == null)
                {
                    _response.IsSuccess = false;
                }

                _response.Result = _mapper.Map<CuponDTO>(objectList);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseCuponDTO Post([FromBody]CuponDTO cuponDTO)
        {
            try
            {

                Cupon obj = _mapper.Map<Cupon>(cuponDTO);
                _db.Cupons.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CuponDTO>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseCuponDTO Put([FromBody] CuponDTO cuponDTO)
        {
            try
            {

                Cupon obj = _mapper.Map<Cupon>(cuponDTO);
                _db.Cupons.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CuponDTO>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        public ResponseCuponDTO Delete(int id)
        {
            try
            {
                Cupon obj = _db.Cupons.First(x => x.CuponId == id);
                _db.Cupons.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
