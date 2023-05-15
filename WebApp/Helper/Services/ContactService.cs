using WebApp.Helper.Repositories;
using WebApp.Models.Entity;
using WebApp.ViewModels;

namespace WebApp.Helper.Services;

public class ContactService
{
    private readonly ContactRepository _contactRepo;

    public ContactService(ContactRepository contactRepo)
    {
        _contactRepo = contactRepo;
    }

    public async Task<ContactFormEntity> RegisterAsync(ContactFormViewModel viewmodel)
    {
        return await _contactRepo.AddAsync(viewmodel);
    }
}
