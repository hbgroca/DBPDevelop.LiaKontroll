using Buisness.Models;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApp.Controllers;

public class HomeController(CompanyRepository companyRepository, SearchesRepository searchesRepository, ResponseRepository responseRepository) : Controller
{

    private readonly CompanyRepository _companyRepository = companyRepository;
    private readonly ResponseRepository _responseRepository = responseRepository;
    private readonly SearchesRepository _searchesRepository = searchesRepository;

    public async Task<IActionResult> Index()
    {
        var companies = await _companyRepository.GetCompanies();
        companies.OrderBy(x => x.Name).ToList();
        // Sort the ResponseEntity by Response time 
        foreach (var company in companies)
        {

            foreach (var search in company.SearchEntity)
            {
                search.ResponseEntity = search.ResponseEntity.OrderBy(r => r.ResponseDate).ToList();
            }
        }

        return View(companies);
    }


    public async Task<IActionResult> AddCompany(AddCompanyFormModel form)
    {
        if(!ModelState.IsValid)
        {
            var errors = ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

            return BadRequest(new { success = false, errors });
        }

        var company = new CompanyEntity
        {
            Name = form.Name,
            Description = form.Description
        };
        company.Id = Guid.NewGuid();
        var result = await _companyRepository.CreateCompany(company);
        if(result == null)
        {
            return BadRequest(new { success = false });
        }

        return Ok(new { success = true });
    }


    public async Task<IActionResult> AddSearch(AddSearchFormModel form)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

            return BadRequest(new { success = false, errors });
        }

        var search = new SearchEntity
        {
            Headline = form.Headline,
            Description = form.Description,
            SearchTime = form.SearchTime,
            CompanyEntityId = form.CompanyId
        };
        search.Id = Guid.NewGuid();
        var result = await _searchesRepository.CreateSearch(search);
        if (result == null)
        {
            return BadRequest(new { success = false });
        }

        return Ok(new { success = true });
    }

    public async Task<IActionResult> AddResponse(AddResponseFormModel form)
    {
        if (form.IsAnswer)
        {
            form.ResponsePerson = "Jag";
            ModelState.Remove("ResponsePerson");
        }


        if (!ModelState.IsValid)
        {
            var errors = ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

            return BadRequest(new { success = false, errors });
        }

        var entity = new ResponseEntity
        {
            Response = form.Response,
            ContactTypeId = form.ContactTypeId,
            ResponseDate = form.ResponseDate,
            SearchEntityId = form.SearchEntityId,
            ResponsePerson = form.ResponsePerson,
            IsAnswer = form.IsAnswer,
            ResponseContactInfo = form.ResponseContactInfo
        };

        entity.Id = Guid.NewGuid();
        var result = await _responseRepository.Create(entity);
        if (result == null)
        {
            return BadRequest(new { success = false });
        }

        return Ok(new { success = true });
    }


    public async Task<IActionResult> DeleteCompnay(Guid id)
    {
        var result = await _companyRepository.DeleteCompany(id);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> DeleteSearch(Guid id)
    {
        var result = await _searchesRepository.DeleteSearch(id);

        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> DeleteResponse(Guid id)
    {
        var result = await _responseRepository.Delete(id);

        return RedirectToAction("Index", "Home");
    }
}
