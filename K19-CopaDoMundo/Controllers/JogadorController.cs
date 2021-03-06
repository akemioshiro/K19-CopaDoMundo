﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K19_CopaDoMundo.Models;

namespace K19_CopaDoMundo.Controllers
{
    public class JogadorController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Create()
        {
            ViewBag.SelecaoId = new SelectList(unitOfWork.SelecaoRepository.Selecoes, "Id", "Pais");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Jogador jogador)
        {
            if(ModelState.IsValid)
            {
                unitOfWork.JogadorRepository.Adiciona(jogador);
                unitOfWork.Salva();
                return RedirectToAction("Index");
            }
            ViewBag.SelecaoId = new SelectList(unitOfWork.SelecaoRepository.Selecoes, "Id", "Pais");
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }


        // GET: Jogador
        public ActionResult Index()
        {
            return View(unitOfWork.JogadorRepository.Jogadores);
        }

        public ActionResult Delete(int id)
        {
            Jogador jogador = unitOfWork.JogadorRepository.Busca(id);
            return View(jogador);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.JogadorRepository.Remove(id);
            unitOfWork.Salva();
            return RedirectToAction("Index");
        }
    }
}