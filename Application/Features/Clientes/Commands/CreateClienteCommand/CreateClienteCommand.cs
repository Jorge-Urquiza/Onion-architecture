using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.CreateClienteCommand
{
    public class CreateClienteCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }
    }
}
