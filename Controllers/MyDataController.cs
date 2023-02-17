using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myown.Models;
using Microsoft.AspNetCore.Mvc;

namespace myown.Controllers
{
    public class MyDataController : Controller
    {
        private List<MyData> _data = new List<MyData>();

        public IActionResult Index()
        {
            Console.WriteLine("meu Deus");
            foreach (var uau in _data)
            {
                Console.WriteLine("Aqui: " + uau.Telefone);
            }
            return View(_data);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            Console.WriteLine("\n\n\nCriar1\n\n\n");
            return View();
        }

        [HttpPost]
        public IActionResult Criar(MyData data)
        {
            Console.WriteLine("\n\n\nCriar2\n\n\n");

            data.Id = _data.Count + 1;
            _data.Add(data);

            foreach (var uau in _data)
            {
                Console.WriteLine("Aqui: " + uau.Telefone);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _data.FirstOrDefault(d => d.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(MyData data)
        {
            var existingData = _data.FirstOrDefault(d => d.Id == data.Id);
            if (existingData == null)
            {
                return NotFound();
            }
            existingData.Nome = data.Nome;
            existingData.Telefone = data.Telefone;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _data.FirstOrDefault(d => d.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _data.FirstOrDefault(d => d.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            _data.Remove(data);
            return RedirectToAction("Index");
        }
    }

}