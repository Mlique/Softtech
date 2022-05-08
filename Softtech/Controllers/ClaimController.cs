using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Softtech.Data;
using Softtech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ResManagementDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClaimController(ResManagementDBContext context,
                                UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var claims = _context.tblClaims.ToList();
            return View(claims);
        }

        public IActionResult New()
        {
            return View(new Models.Claim());
        }

        [HttpPost]
        public async Task<IActionResult> New(Models.Claim claim)
        {
            if (!ModelState.IsValid)
                return View(claim);

            claim.ClaimValue = claim.ClaimValue.ToString();

            _context.tblClaims.Add(claim);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AssignClaimToUser(string userId)
        {
            var claims = _context.tblClaims.ToList();
            claims = claims.Select(x =>
            {
                x.ClaimType = $"Type = {x.ClaimType} and Value = {x.ClaimValue}";
                return x;
            }).ToList();

            ViewBag.Claims = new SelectList(claims, "Id", "ClaimType");

            var user = await _userManager.FindByIdAsync(userId);
            ViewBag.UserName = user.UserName;
            ViewBag.UserId = userId;

            var userClaims = await _userManager.GetClaimsAsync(user);

            return View(userClaims);
        }

        [HttpPost]
        public async Task<IActionResult> AssignClaimToUser(string userId, int claimId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var claim = _context.tblClaims.FirstOrDefault(x => x.Id == claimId);

            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(claim.ClaimType, claim.ClaimValue));

            return RedirectToAction(nameof(AssignClaimToUser), new { userId = userId });
        }

        [HttpGet]
        public async Task<IActionResult> RemoveClaimFromUser(string userId, string claimType, string claimValue)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.RemoveClaimAsync(user, new System.Security.Claims.Claim(claimType, claimValue));
            return RedirectToAction(nameof(AssignClaimToUser), new { userId = userId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var claim = _context.tblClaims.FirstOrDefault(x => x.Id == id);
            _context.tblClaims.Remove(claim);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}