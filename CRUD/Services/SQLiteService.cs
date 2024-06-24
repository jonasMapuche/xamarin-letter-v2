using CRUD.Helpers;
using CRUD.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class SQLiteService
    {
        static SQLiteAsyncConnection Database;

        public SQLiteService()
        {
            string DataBasePach = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "letter.db");
            Database = new SQLiteAsyncConnection(DataBasePach);
            Database.CreateTableAsync<Substantivo>().Wait();
            Database.CreateTableAsync<Verbo>().Wait();
            Database.CreateTableAsync<Pronome>().Wait();
            Database.CreateTableAsync<Adjetivo>().Wait();
            Database.CreateTableAsync<Adverbio>().Wait();
            Database.CreateTableAsync<Artigo>().Wait();
            Database.CreateTableAsync<Preposicao>().Wait();
            Database.CreateTableAsync<Numeral>().Wait();
            Database.CreateTableAsync<Conjuncao>().Wait();
            Database.CreateTableAsync<Interjeicao>().Wait();
            Database.CreateTableAsync<Pronomes>().Wait();
            Database.CreateTableAsync<Artigos>().Wait();
            Database.CreateTableAsync<Preposicoes>().Wait();
        }

        public async Task CreateAsync(List<Aula> aula, List<Estoutro> estoutro, List<Preceito> preceito, List<Juncao> juncao)
        {
            await Substantivo(aula);
            await Verbo(aula);
            await Pronome(aula);
            await Adjetivo(aula);
            await Adverbio(aula);
            await Artigo(aula);
            await Preposicao(aula);
            await Numeral(aula);
            await Conjuncao(aula);
            await Interjeicao(aula);
            await Pronomes(estoutro);
            await Artigos(preceito);
            await Preposicoes(juncao);
        }

        private async Task Substantivo(List<Aula> aula)
        {
            List<Substantivo> substantivo = new List<Substantivo>();
            aula.ForEach(index =>
            {
                index.conteudo.substantivo.ForEach(index2 =>
                {
                    Substantivo item = new Substantivo();
                    item.name = index2;
                    item.lesson = index.nome;
                    item.language = Language.Lesson(index.nome);
                    if (item.name != "") substantivo.Add(item);
                }
                );
            }
            );
            await Database.InsertAllAsync(substantivo);
        }

        private async Task Verbo(List<Aula> aula)
        {
            List<Verbo> verbo = new List<Verbo>();
            aula.ForEach(index =>
            {
                index.conteudo.verbo.ForEach(index2 =>
                {
                    Verbo item = new Verbo();
                    item.name = index2;
                    item.lesson = index.nome;
                    item.language = Language.Lesson(index.nome);
                    if (item.name != "") verbo.Add(item);
                }
                );
            }
            );
            await Database.InsertAllAsync(verbo);
        }

        private async Task Pronome(List<Aula> aula)
        {
            List<Pronome> pronome = new List<Pronome>();
            aula.ForEach(index =>
            {
                index.conteudo.pronome.ForEach(index2 =>
                {
                    Pronome item = new Pronome();
                    item.name = index2;
                    item.lesson = index.nome;
                    item.language = Language.Lesson(index.nome);
                    if (item.name != "") pronome.Add(item);
                }
                );
            }
            );
            await Database.InsertAllAsync(pronome);
        }

        private async Task Adjetivo(List<Aula> aula)
        {
            List<Adjetivo> adjetivo = new List<Adjetivo>();
            aula.ForEach(index =>
            {
                index.conteudo.adjetivo.ForEach(index2 =>
                {
                    Adjetivo item = new Adjetivo();
                    item.name = index2;
                    item.lesson = index.nome;
                    item.language = Language.Lesson(index.nome);
                    if (item.name != "") adjetivo.Add(item);
                }
                );
            }
            );
            await Database.InsertAllAsync(adjetivo);
        }

        private async Task Adverbio(List<Aula> aula)
        {
            List<Adverbio> adverbio = new List<Adverbio>();
            aula.ForEach(index =>
            {
                index.conteudo.adverbio.ForEach(index2 =>
                {
                    Adverbio item = new Adverbio();
                    item.name = index2;
                    item.lesson = index.nome;
                    item.language = Language.Lesson(index.nome);
                    if (item.name != "") adverbio.Add(item);
                }
                );
            }
            );
            await Database.InsertAllAsync(adverbio);
        }

        private async Task Artigo(List<Aula> aula)
        {
            List<Artigo> artigo = new List<Artigo>();
            aula.ForEach(index =>
            {
                index.conteudo.artigo.ForEach(index2 =>
                {
                    Artigo item = new Artigo();
                    item.name = index2;
                    item.lesson = index.nome;
                    item.language = Language.Lesson(index.nome);
                    if (item.name != "") artigo.Add(item);
                }
                );
            }
            );
            await Database.InsertAllAsync(artigo);
        }

        private async Task Preposicao(List<Aula> aula)
        {
            List<Preposicao> preposicao = new List<Preposicao>();
            aula.ForEach(index =>
            {
                index.conteudo.preposicao.ForEach(index2 =>
                {
                    Preposicao item = new Preposicao();
                    item.name = index2;
                    item.lesson = index.nome;
                    item.language = Language.Lesson(index.nome);
                    if (item.name != "") preposicao.Add(item);
                }
                );
            }
            );
            await Database.InsertAllAsync(preposicao);
        }

        private async Task Numeral(List<Aula> aula)
        {
            List<Numeral> numeral = new List<Numeral>();
            aula.ForEach(index =>
            {
                index.conteudo.numeral.ForEach(index2 =>
                {
                    Numeral item = new Numeral();
                    item.name = index2;
                    item.lesson = index.nome;
                    item.language = Language.Lesson(index.nome);
                    if (item.name != "") numeral.Add(item);
                }
                );
            }
            );
            await Database.InsertAllAsync(numeral);
        }

        private async Task Conjuncao(List<Aula> aula)
        {
            List<Conjuncao> conjuncao = new List<Conjuncao>();
            aula.ForEach(index =>
            {
                index.conteudo.conjuncao.ForEach(index2 =>
                {
                    Conjuncao item = new Conjuncao();
                    item.name = index2;
                    item.lesson = index.nome;
                    item.language = Language.Lesson(index.nome);
                    if (item.name != "") conjuncao.Add(item);
                }
                );
            }
            );
            await Database.InsertAllAsync(conjuncao);
        }

        private async Task Interjeicao(List<Aula> aula)
        {
            List<Interjeicao> interjeicao = new List<Interjeicao>();
            aula.ForEach(index =>
            {
                index.conteudo.interjeicao.ForEach(index2 =>
                {
                    Interjeicao item = new Interjeicao();
                    item.name = index2;
                    item.lesson = index.nome;
                    item.language = Language.Lesson(index.nome);
                    if (item.name != "") interjeicao.Add(item);
                }
                );
            }
            );
            await Database.InsertAllAsync(interjeicao);
        }

        private async Task Pronomes(List<Estoutro> estrouto)
        {
            List<Pronomes> pronomes = new List<Pronomes>();
            estrouto.ForEach(in_pronoun =>
            {
                in_pronoun.tipo.ForEach(in_tipo =>
                {
                    in_pronoun.contento.ForEach(in_content =>
                    {
                        in_content.pessoa.ForEach(in_person =>
                        {
                            in_content.numero.ForEach(in_number =>
                            {
                                in_content.genero.ForEach(in_gender =>
                                {
                                    in_content.contexto.ForEach(in_context =>
                                    {
                                        Pronomes item = new Pronomes();
                                        item.name = in_pronoun.nome;
                                        item.language = in_pronoun.linguagem;
                                        item.type = in_tipo;
                                        item.person = in_person;
                                        item.number = in_number;
                                        item.gender = in_gender;
                                        item.context = in_context;
                                        pronomes.Add(item);
                                    }
                                    );
                                }
                                );
                            }
                            );
                        }
                        );
                    }
                    );
                }
                );
            }
            );
            await Database.InsertAllAsync(pronomes);
        }

        private async Task Artigos(List<Preceito> preceito)
        {
            List<Artigos> artigos = new List<Artigos>();
            preceito.ForEach(in_preceito =>
            {
                in_preceito.tipo.ForEach(in_type =>
                {
                    in_preceito.numero.ForEach(in_number =>
                    {
                        in_preceito.genero.ForEach(in_gender =>
                        {
                            Artigos item = new Artigos();
                            item.name = in_preceito.nome;
                            item.language = in_preceito.linguagem;
                            item.type = in_type;
                            item.number = in_number;
                            item.gender = in_gender;
                            artigos.Add(item);
                        }
                        );
                    }
                    );
                }
                );
            }
            );
            await Database.InsertAllAsync(artigos);
        }

        private async Task Preposicoes(List<Juncao> juncao)
        {
            List<Preposicoes> preposicoes = new List<Preposicoes>();
            juncao.ForEach(in_juncao =>
            {
                in_juncao.tipo.ForEach(in_type =>
                {
                    Preposicoes item = new Preposicoes();
                    item.name = in_juncao.nome;
                    item.language = in_juncao.linguagem;
                    item.type = in_type;
                    preposicoes.Add(item);
                }
                );
            }
            );
            await Database.InsertAllAsync(preposicoes);
        }
    }
    }