﻿using DAL.DataAccessObject;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ServicosService : IService<Servicos>
    {
        private readonly ServicosDAO servicosDao = null;

        public ServicosService() => this.servicosDao = new ServicosDAO();

        public async Task<IList<Servicos>> ListarTodos()
        {
            return await servicosDao.ListarTodos();
        }

        public async Task<Servicos> BuscarPorID(int id)
        {
            return await servicosDao.BuscarPorID(id);
        }

        public async Task<Servicos> Inserir(Servicos servico)
        {
            servico.PrepareSave();
            servico.Ativar();
            return await servicosDao.Inserir(servico);
        }

        public async Task<Servicos> Editar(Servicos servico)
        {
            servico.PrepareSave();
            return await servicosDao.Editar(servico);
        }

        public async Task<bool> Excluir(int codigo)
        {
            Servicos servico = new Servicos();
            servico.codigo = codigo;
            servico.PrepareSave();
            servico.Inativar();
            return await servicosDao.Excluir(servico);
        }

        public async Task<IList<Servicos>> Pesquisar(string str)
        {
            return await servicosDao.Pesquisar(str);
        }
    }
}