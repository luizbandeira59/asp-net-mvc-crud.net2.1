using System;


//Data Acess Layer - Camada de acesso a dados - DAL - responsável por realizar o acesso e a persistência aos dados fazendo a comunicação entre a BLL e UI;.
//BLL – Camada de Regra de negócios(Business Logic Layer); UI – Camada de Apresentação(User Interface)

namespace CrudAspNetMVC.Data.CamadaAcessoDados.Erros
{
    public class DbConcurrencyException : ApplicationException
    {

        public DbConcurrencyException(string message) : base(message)
        {

        }
    }
}