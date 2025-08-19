using AppView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AppView.Pages.NhanVien
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<NhanVienDto> DanhSachNhanVien { get; set; } = new();

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7253/api/NhanViens");
            Console.WriteLine("Status code: " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine("JSON nhận được từ API:");
                Console.WriteLine(json);
                DanhSachNhanVien = JsonConvert.DeserializeObject<List<NhanVienDto>>(json);
            }
            else
            {

            }    
        }
    }
}
