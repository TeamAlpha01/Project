using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using IMS.Service;
using IMS.Models;

[Route("api/[controller]")]
[ApiController]
public class MailController : ControllerBase
{
    private IMailService mailService;
    public MailController(IMailService mailService)
    {
        this.mailService = mailService;
    }
    [HttpPost("send")]
    public async Task<IActionResult> SendMail([FromForm]MailRequest request)
    {
        try
        {
            await mailService.SendEmailAsync(request,true);
            return Ok();
        }
        catch (Exception ex)
        {
            throw;
        }
            
    }
}