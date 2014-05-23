﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTickets.Web.Models
{
    public class Espetaculo
    {
        // propriedades
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual IList<Sessao> Sessoes { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }

        public Espetaculo()
        {
            this.Sessoes = new List<Sessao>();
        }
        /*
         * Esse metodo eh responsavel por criar sessoes para
         * o respectivo espetaculo, dado o intervalo de inicio e fim,
         * mais a periodicidade.
         * 
         * O algoritmo funciona da seguinte forma:
         * - Caso a data de inicio seja 01/01/2010, a data de fim seja 03/01/2010,
         * e a periodicidade seja DIARIA, o algoritmo cria 3 sessoes, uma 
         * para cada dia: 01/01, 02/01 e 03/01.
         * 
         * - Caso a data de inicio seja 01/01/2010, a data fim seja 31/01/2010,
         * e a periodicidade seja SEMANAL, o algoritmo cria 5 sessoes, uma
         * a cada 7 dias: 01/01, 08/01, 15/01, 22/01 e 29/01.
         * 
         * Repare que a data da primeira sessao é sempre a data inicial.
         */
        public virtual IList<Sessao> CriaSessoes(DateTime inicio, DateTime fim, Periodicidade periodicidade)
        {
            // ALUNO: Não apague esse metodo. Esse sim será usado no futuro! ;)
            switch (periodicidade)
            { 
                case Periodicidade.DIARIA:
                    break;
                case Periodicidade.SEMANAL:
                    break;
                default:
                    break;
            
            }

            return null;
        }

        public virtual bool Vagas(int qtd, int min)
        {
            // ALUNO: Não apague esse metodo. Esse sim será usado no futuro! ;)
            int totDisp = 0;

            if (!TemIngressoDisponivel(min))
            {
                return false;
            }
            
            totDisp = TotalIngressoDisponivel();
            
            return (totDisp >= qtd);
        }

        private bool TemIngressoDisponivel(int min)
        {
            foreach (Sessao s in Sessoes)
            {
                if (s.IngressosDisponiveis < min)
                    return false;
            }
            return true;
        }

        public virtual bool Vagas(int qtd)
        {
            // ALUNO: Não apague esse metodo. Esse sim será usado no futuro! ;)
            int totDisp = TotalIngressoDisponivel();

            return (totDisp >= qtd);
        }

        private int TotalIngressoDisponivel()
        {
            int totDisp = 0;
            foreach (Sessao s in Sessoes)
            {
                totDisp += s.IngressosDisponiveis;
            }
            return totDisp;
        }

        private void CriaSessaoSemanal()
        { }

        private void CriaSessaoDiaria()
        { }
    }
}