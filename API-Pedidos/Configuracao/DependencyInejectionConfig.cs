using Dados.AppContext;
using Dados.Repository;
using Microsoft.Extensions.DependencyInjection;
using Negocios.Interface.InterfaceCliente;
using Negocios.Interface.InterfaceNotificador;
using Negocios.Interface.InterfacePedido;
using Negocios.Interface.InterfacePedidoItem;
using Negocios.Interface.InterfaceProduto;
using Negocios.Interface.InterfaceRepository;
using Negocios.Model;
using Negocios.Notificacoes;
using Negocios.Service.ClienteService;
using Negocios.Service.ClienteService.Interface;
using Negocios.Service.PedidoItemService;
using Negocios.Service.PedidoItemService.Interface;
using Negocios.Service.PedidoService;
using Negocios.Service.PedidoService.Interface;
using Negocios.Service.ProdutoService;
using Negocios.Service.ProdutoService.Interface;

namespace API_Pedidos.Configuracao
{
    public static class DependencyInejectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped(typeof(IRepository<Produto>), typeof(Repository<Produto>));
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IPedidoItemService, PedidoItemService>();
            return services;
        }
    }
}
