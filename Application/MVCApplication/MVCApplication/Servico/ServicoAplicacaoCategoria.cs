﻿using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCApplication.Models;
using MVCApplication.Servico.Interfaces;
using System.Collections.Generic;

namespace MVCApplication.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly ICategoriaService CategoriaService;

        public ServicoAplicacaoCategoria(ICategoriaService categoriaService)
        {
            CategoriaService = categoriaService;
        }
        public void Cadastrar(CategoriaViewModel categoria)
        {
            Categoria item = new()
            {
                Codigo = categoria.Codigo,
                Descricao = categoria.Descricao
            };

            if (categoria.Codigo == null)
                CategoriaService.Cadastrar(item);
            else
                CategoriaService.Atualizar(item);
        }


        public CategoriaViewModel CarregarRegistro(string codigoCategoria)
        {
            var registro = CategoriaService.CarregarRegistro(codigoCategoria);

            CategoriaViewModel categoria = new()
            { 
                Codigo = registro.Codigo,
                Descricao = registro.Descricao
            };
            return categoria;
        }

        public void Excluir(string id)
        {
            CategoriaService.Excluir(id.ToString());
        }

        public IEnumerable<SelectListItem> ListaCategoriaDropDownList()
        {
            List<SelectListItem> retorno = new();
            var lista = this.Listagem();

            foreach (var item in lista)
            {
                SelectListItem categoria = new()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };
                retorno.Add(categoria);
            }
            return retorno;
        }

        public IEnumerable<CategoriaViewModel> Listagem()
        {
            var lista = CategoriaService.Listagem();
            List<CategoriaViewModel> listaCategoria = new();

            foreach (var item in lista)
            {
                CategoriaViewModel categoria = new()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao
                };
                listaCategoria.Add(categoria);
            }

            return listaCategoria;
        }
    }
}
