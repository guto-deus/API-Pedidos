using API_Pedidos.ViewModel;
using AutoMapper;
using Negocios.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pedidos.Configuracao
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ClienteViewModel, Cliente>().ReverseMap();
            CreateMap<PedidoViewModel, Pedido>().ReverseMap();
            CreateMap<PedidoItemViewModel, PedidoItem>().ReverseMap();
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
        }
    }
}