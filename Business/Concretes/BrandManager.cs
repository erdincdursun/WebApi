using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDAl;

    public BrandManager(IBrandDal brandDAl)
    {
        _brandDAl = brandDAl;
    }

    public CreatedBrandResponse Add(CreateBrandRequest createBrandRequest)
    {
        //business rule

        //mapping
        Brand brand = new();
        brand.Name = createBrandRequest.Name;

        //mapping
        _brandDAl.Add(brand);
        CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
        createdBrandResponse.Name = brand.Name;
        createdBrandResponse.Id = 4;
        createdBrandResponse.CreatedDate = brand.CreatedDate;

        return createdBrandResponse;
    }

    public List<GetAllBrandResponse> GetAll()
    {
        List<Brand> brands = _brandDAl.GetAll();
        List<GetAllBrandResponse> getAllBrandResponses = new List<GetAllBrandResponse>();
        foreach (var brand in brands)
        {
            GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();
            getAllBrandResponse.Name = brand.Name;
            getAllBrandResponse.Id = brand.Id;
            getAllBrandResponse.CreatedDate = brand.CreatedDate;

            getAllBrandResponses.Add(getAllBrandResponse);
        }
        return getAllBrandResponses;
    }
}
