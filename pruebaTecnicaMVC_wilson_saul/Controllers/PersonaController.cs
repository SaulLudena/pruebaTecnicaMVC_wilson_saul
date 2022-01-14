using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pruebaTecnicaMVC_wilson_saul.Models;

namespace pruebaTecnicaMVC_wilson_saul.Controllers
{
    public class PersonaController : Controller
    {
        //objeto de tipo personaDocumentoEntities
        CAPACITACIONEntities context = new CAPACITACIONEntities();

        // Metodo que lista a las personas
        public ActionResult Index()
        {
            return View(context.Persona.ToList());
        }

        //Metodo para crear una persona
        public ActionResult CrearPersona()
        {
            ViewBag.TipoDocumento = new SelectList(context.TipoDocumento.ToList(), "Id", "Abreviatura");
            return View();
        }

        [HttpPost]
        public ActionResult CrearPersona(Persona model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TipoDocumento = new SelectList(context.TipoDocumento.ToList(), "Id", "Abreviatura");
                return View();
            }
            else
            {
                var tipoDocumento = context.TipoDocumento.Find(model.TipoDocumentoId);
                model.TipoDocumento = tipoDocumento;
                context.Persona.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        public ActionResult EditarPersona(int id) {
            ViewBag.TipoDocumento = new SelectList(context.TipoDocumento.ToList(), "Id", "Abreviatura");
            var persona = context.Persona.Find(id); 
            return View(persona); 
        }

        [HttpPost]
        public ActionResult EditarPersona(Persona model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TipoDocumento = new SelectList(context.TipoDocumento.ToList(), "Id", "Abreviatura");
                return View();
            }

                var documento = context.TipoDocumento.Find(model.TipoDocumentoId);

                model.TipoDocumento = documento;
                context.Persona.Attach(model);
                context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");

            
        }
        public ActionResult PersonaDetalle(int id)
        {
            var persona = context.Persona.Find(id);
            return View(persona);
        }

        public ActionResult EliminarPersona(int id)
        {
            var persona = context.Persona.Find(id);
            if(persona != null)
            {
                context.Persona.Remove(persona);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}