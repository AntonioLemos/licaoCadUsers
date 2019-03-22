using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LicaoUnica2.Models.Domain;
using LiçãoUnica2.Models.Context;
using LicaoUnica2.Models.ViewModels;

namespace LicaoUnica2.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Context _context;

        public UsuariosController(Context context)
        {
            _context = context;    
        }

        // GET: Usuarios/Create
        [HttpGet]
        public ActionResult AddUsuarios(int x)
        {
            bool y;
            if (x != 1)
                y = true;
            else
                y = false;

            return View(new UsuarioViewModel
            {
                statusError = true,
                statusConfir = y
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUsuarios(UsuarioViewModel usuario)
        {
                if(!Usuariosigom(usuario.Cpf) || (!cpfexist(usuario.Cpf)))
                {
                    usuario.statusConfir = true;
                    usuario.statusError = false;
                    return View(usuario);
                }

                try
                {
                    _context.Usuario.Add(new Usuario
                    {
                        NomeUsuario = usuario.NomeUsuario,
                        Email = usuario.Email,
                        Cpf = usuario.Cpf,
                        User = usuario.User,
                        Senha = usuario.Password,
                    });
                //  _context.SaveChangesAsync();
                    _context.SaveChanges();
            } catch (Exception)
                {
                    //return View(usuario);
                };

            return RedirectToAction("AddUsuarios", "Usuarios", new { @x = 1 });
        }


        public bool cpfexist(string cpf)
        {
            Usuario novoUser = _context.Usuario.Where(x => x.Cpf == cpf).FirstOrDefault();
            if (novoUser == null)
                return true;

            return false;
        }

        public bool Usuariosigom(string cpf)
        {
            if (!ValidaCPF(cpf))
                return false;

            return true;
        }

        public static bool ValidaCPF(string cpf)
        {
            //Remove formatação do número, ex: "123.456.789-01" vira: "12345678901"
            cpf = RemoveNaoNumericos(cpf);
            if (cpf.Length > 11)
                return false;
            while (cpf.Length != 11)
                cpf = '0' + cpf;
            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;
            if (igual || cpf == "12345678909")
                return false;
            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];
            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];
            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;
            return true;
        }

        public static string RemoveNaoNumericos(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }




    }
}
