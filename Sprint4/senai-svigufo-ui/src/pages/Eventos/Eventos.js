import React, { Component } from 'react';
import Rodape from '../Components/Rodape/Rodape';
import Axios from 'axios';

class Cadastro extends Component {
    constructor(){
        super();
        this.state={
            lista:[],
            id:"",
            titulo:"",
            dataevento:"",
            instituicaoId:1,
            acessolivre:"",
            descricao:"",
            listaTiposEventos:[],
            tipoEventoId:""
          
        };
    }
    atualizaEstadoTitulo(event){
        this.setState({titulo:event.target.value})
    }
    atualizaEstadoDataEvento(event){
        this.setState({dataevento:event.target.value})   
    }
    atualizaEstadoAcessoLivre(event){
        this.setState({acessolivre:event.target.value})
    }
    atualizaEstadoTipoEventoId(event){
        this.setState({tipoEventoId:event.target.value})
    }
    
    atualizaEstadoDescricao(event){
        this.setState({descricao:event.target.value})
    }
    Cadastrar(event){
        event.preventDefault();
        
        Axios.post('http://192.168.4.112:5000/api/eventos',{
            titulo:this.state.titulo,
            descricao:this.state.descricao,
            dataevento:this.state.dataevento,
            acessolivre:this.state.acessolivre,
            tipoEventoId:this.state.tipoEventoId,
            instituicaoId:1
        }, {
            headers: {
                'Content-Type' : 'application/json',
                'Authorization' : 'Bearer ' + localStorage.getItem("usuario-svigufo")
            }
        })
        .then(data=>console.log(data))
        .catch(erro=>console.log(erro))
       
        alert("cadastrado");
        
    }
    ListarEventos(){
        
        Axios.get('http://192.168.4.112:5000/api/eventos',{
            headers: {
            'Content-Type' : 'application/json',
            'Authorization' : 'Bearer ' + localStorage.getItem("usuario-svigufo")
    }
        })
        .then(data=>{
            this.setState({lista:data});
            this.setState({listaTiposEventos:data});
        })
        .catch(erro => console.log(erro))
    }


    buscaTipoEventos(){
        Axios.get('http://192.168.4.112:5000/api/tiposeventos')
        .then(res=>{
            const tiposeventos = res.data;
            this.setState({listaTiposEventos:tiposeventos})
        })
    }
    componentDidMount(){
        this.ListarEventos();
        this.buscaTipoEventos();
    }
    render() {
        return (
            <div>
                <header className="cabecalhoPrincipal">
                    <div className="container">
                        <img src="./assets/img/icon-login.png" />

                        <nav className="cabecalhoPrincipal-nav">
                            Administrador
      </nav>
                    </div>
                </header>

                <main className="conteudoPrincipal">
                    <section className="conteudoPrincipal-cadastro">
                        <h1 className="conteudoPrincipal-cadastro-titulo">Eventos</h1>
                        <div className="container" id="conteudoPrincipal-lista">

                            <table id="tabela-lista">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Evento</th>
                                        <th>Data</th>
                                        <th>Acesso Livre</th>
                                        <th>Tipo do Evento</th>
                                    </tr>
                                </thead>

                                <tbody id="tabela-lista-corpo">{
                                    this.state.lista.map(function (evento) {
                                       return(
                                        <tr key={evento.id}>
                                            <td>{evento.id}</td>
                                            <td>{evento.titulo}</td>
                                            <td>{evento.dataevento}</td>
                                            <td>{evento.acessolivre}</td>
                                            <td>{evento.listaTiposEventos}</td>
                                        </tr>
                                       );
                                    })
                                }</tbody>
                            </table>


                        </div>
                            <div className="container" id="conteudoPrincipal-cadastro">
                                <h2 className="conteudoPrincipal-cadastro-titulo">Cadastrar Evento</h2>
                        <form onSubmit={this.Cadastrar.bind(this)}>
                                <div className="container">

                                    <input type="text" id="evento__titulo" placeholder="título do evento" value={this.state.titulo} onChange={this.atualizaEstadoTitulo.bind(this)}/>
                                    <input type="text" id="evento__data" placeholder="dd/MM/yyyy" value={this.state.dataevento} onChange={this.atualizaEstadoDataEvento.bind(this)}/>
                                    <select id="option__acessolivre" value={this.state.acessolivre} onChange={this.atualizaEstadoAcessoLivre.bind(this)}>
                                        <option value="1">Livre</option>
                                        <option value="0">Restrito</option>
                                    </select>
                                    <select id="option__tipoevento" value={this.state.tipoEventoId} onChange={this.atualizaEstadoTipoEventoId.bind(this)} >
                                        <option value="0">Selecione</option>
                                        {
                                            this.state.listaTiposEventos.map((element)=>{
                                                return <option key={element.id} value={element.id}>{element.nome}</option>
                                            })
                                        }
                                    </select>
                                    <textarea rows="3" cols="50" placeholder="descrição do evento" id="evento__descricao" value={this.state.descricao} onChange={this.atualizaEstadoDescricao.bind(this)}></textarea>

                                </div>
                                <button type="submit" className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro"
                                >Cadastrar</button>
                        </form>
                            </div>


                    </section>
                </main>

                <Rodape />
            </div>
        );
    }
}
export default Cadastro;