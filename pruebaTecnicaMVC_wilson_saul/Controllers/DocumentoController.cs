using pruebaTecnicaMVC_wilson_saul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pruebaTecnicaMVC_wilson_saul.Controllers
{
    public class DocumentoController : Controller
    {
        //objeto de tipo personaDocumentoEntities
        CAPACITACIONEntities context = new CAPACITACIONEntities();

        public ActionResult Index() {
            return View(context.TipoDocumento.ToList());
        }

        public ActionResult CrearDocumento() {
            return View();
        }

        [HttpPost]
        public ActionResult CrearDocumento(TipoDocumento model) {
            if (!ModelState.IsValid)
            {

                return View();
            }
            {
                context.TipoDocumento.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        public ActionResult EditarDocumento(int id)
        {
            var documento = context.TipoDocumento.Find(id);
            return View(documento);
        }

        [HttpPost]
        public ActionResult EditarDocumento(TipoDocumento model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            {
                context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult DetalleDocumento(int id)
        {
            var detalleDoc = context.TipoDocumento.Find(id);
            return View(detalleDoc);
        }

        //Al borrar un registro, se crea un conflicto
        public ActionResult EliminarDocumento(int id) {
            var documento = context.TipoDocumento.Find(id);

            if(documento != null)
            {
                context.TipoDocumento.Remove(documento);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}