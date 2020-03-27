using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models; //Essa chamada especificar a chamada do Models na aplicação

namespace WebApplication1.Controllers
{
    public class RegistroController : Controller
    {
        BaseDedadosEntities db = new BaseDedadosEntities();
        // GET: Registro
        public ActionResult SetDatainDataBase() //Aqui vai o nome da View que você criou
        {
            return View(); 
        }

        //A notação post segui
        [HttpPost]
        public ActionResult SetDatainDataBase(Usuario model) //Aqui vai o nome da View que você criou
        {
            Usuario tbUsuario = new Usuario();
            int valor = tbUsuario.ID;
            tbUsuario.Username = model.Username;
            tbUsuario.Passaword = model.Passaword;
            db.Usuarios.Add(tbUsuario);
            db.SaveChanges();
            return View();
        }

        public ActionResult ShowDataBaseForUser()
        {

            var item = db.Usuarios.ToList();
            return View(item);
        }

        public ActionResult Delete(int IdParametro)
        {
            var item = db.Usuarios.Where(x => x.ID == IdParametro).First();
            db.Usuarios.Remove(item);
            db.SaveChanges();
            var item2 = db.Usuarios.ToList();           
            return View("ShowDataBaseForUser", item2);
        }

        //Aqui você chama as configurações que vão carregar o 
        //Essa controller simplesmente joga todos os dados para a tela quando você seleciona o item em editar
        public ActionResult Editar(int id)
        {
            // var item = db.Usuarios.ToList();
            var item = db.Usuarios.Where(x => x.ID == id).First(); //Seleciona o Item X que seja igual ao item passado como parametro que foi o 
                                                                                 //selecionado na tela de mostrar dados e retornar para preencher em tela
           
            return View(item); //O fato de retornar o item significa que está ocorrendo o retorno do dado para preencher na tela
        }

        [HttpPost] //O metodo do tipo Posto é denotado para identificar na aplicação que aceite os dados enviados
        public ActionResult Editar(Usuario usuario)
        {
            var item = db.Usuarios.Where(x => x.ID == usuario.ID).First();
            item.Username = usuario.Username;
            item.Passaword = usuario.Passaword;           
            db.SaveChanges();
            return View();
        }
       
    }
}