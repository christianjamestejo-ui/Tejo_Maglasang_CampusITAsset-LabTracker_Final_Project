using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;
using MT_Campus_IT_Asset___Lab_Tracker.Models;

namespace CampusAssetTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AssetsController : ControllerBase
{
    private readonly IAssetRepository _repository;
    private readonly AssetService _service;

    public AssetsController(
        IAssetRepository repository,
        AssetService service)
    {
        _repository = repository;
        _service = service;
    }

    // GET: api/assets
    [HttpGet]
    public ActionResult<List<CampusAsset>> GetAll()
    {
        return Ok(_service.GetAvailableAssets());
    }

    // GET: api/assets/{assetId}
    [HttpGet("{assetId}")]
    public ActionResult<CampusAsset> GetById(string assetId)
    {
        CampusAsset? asset = _repository.GetById(assetId);

        if (asset == null)
            return NotFound("Asset not found.");

        return Ok(asset);
    }

    // GET: api/assets/checked-out
    //[HttpGet("checked-out")]
    //public ActionResult<List<CampusAsset>> GetCheckedOut()
    //{
    //    return Ok(_service.GetBorrowedAssets());
    //}

    // GET: api/assets/available
    [HttpGet("available")]
    public ActionResult<List<CampusAsset>> GetAvailable()
    {
        return Ok(_service.GetAvailableAssets());
    }

    // GET: api/assets/networkable
    [HttpGet("networkable")]
    public ActionResult<List<CampusAsset>> GetNetworkable()
    {
        List<CampusAsset> devices = _service.GetAvailableAssets()
            .Where(asset => asset is INetworkable)
            .ToList();

        return Ok(devices);
    }

    // GET: api/assets/maintenance-due
    //[HttpGet("maintenance-due")]
    //public ActionResult<List<CampusAsset>> GetMaintenanceDue()
    //{
    //    return Ok(_service.GetMaintenanceDueAssets());
    //}

    // POST: api/assets
    [HttpPost]
    public IActionResult Create([FromBody] CampusAsset asset)
    {
        try
        {
            _service.RegisterAsset(asset);

            return CreatedAtAction(
                nameof(GetById),
                new { assetId = asset.AssetId },
                asset
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    // PUT: api/assets/{assetId}
    [HttpPut("{assetId}")]
    public IActionResult Update(
        string assetId,
        [FromBody] CampusAsset asset)
    {
        if (!string.Equals(
            assetId,
            asset.AssetId,
            StringComparison.OrdinalIgnoreCase))
        {
            return BadRequest(
                "Route Asset ID must match request body Asset ID.");
        }

        try
        {
            bool updated = _service.UpdateAsset(asset);

            if (!updated)
                return NotFound("Asset not found.");

            return Ok(asset);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    // DELETE: api/assets/{assetId}
    [HttpDelete("{assetId}")]
    public IActionResult Delete(string assetId)
    {
        bool deleted = _service.DeleteAsset(assetId);

        if (!deleted)
            return NotFound("Asset not found.");

        return NoContent();
    }

    // GET: api/assets/{assetId}/depreciation
    [HttpGet("{assetId}/depreciation")]
    public IActionResult GetDepreciation(string assetId)
    {
        CampusAsset? asset = _repository.GetById(assetId);

        if (asset == null)
            return NotFound("Asset not found.");

        return Ok(new
        {
            asset.AssetId,
            asset.AssetTag,
            //AssetType = asset.GetAssetType(),
            asset.PurchasePrice,
            AnnualDepreciationExpense = asset._annualDepreciationExpense.ToString("N2"),
            Depreciation = asset.CalculateDepreciation(),
            CurrentValue = asset.CalculateCurrentValue()
        });
    }
}
