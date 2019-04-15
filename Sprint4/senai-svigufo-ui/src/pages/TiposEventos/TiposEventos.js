import React, { Component } from 'react';
import Rodape from '../Components/Rodape/Rodape'
import logo from '../../assets/img/icon-login.png';
import Titulo from '../Components/Titulo';
class TiposEventos extends Component {
    constructor(){
        super();
        this.state = {
            lista :[],
            nome:"",
            titulomensagem :"Olá,Tipos Eventos"
        }
        this.atualizaEstadoNomeForm = this.atualizaEstadoNome.bind(this);
        
    }
    buscarTiposEventos(){
        fetch('http://192.168.4.112:5000/api/tiposeventos')
        .then(respota=>respota.json())
        .then(data=>this.setState({lista:data}))
        .catch(erro=>console.log('erro pra listar',erro))
    }
    atualizaEstadoNome(event){
        this.setState({nome:event.target.value})
    }
    CadastrarTipoEvento(event){
        event.preventDefault();
        fetch('http://192.168.4.112:5000/api/tiposeventos',{
            method:'POST',
            body:JSON.stringify({nome:this.state.nome}),
            headers:{
                "Content-Type":"application/json"
            }
        })
        .then(response=>response)
        .then(this.buscarTiposEventos())
        .catch(erro=>console.log("deu erro",erro))

    }
    componentDidMount(){
        this.buscarTiposEventos();
    }
    render() {
        return (
            <div>
                <header className="cabecalhoPrincipal">
                    <div className="container">
                        <img src={logo} />

                        <nav className="cabecalhoPrincipal-nav">
                            Administrador
                </nav>
                    </div>
                </header>

                <main className="conteudoPrincipal">
                    <section className="conteudoPrincipal-cadastro">
                    <Titulo mensagem={this.state.titulomensagem} />
                    
                        <div className="container" id="conteudoPrincipal-lista">
                            <table id="tabela-lista">
                                <thead>
                                    <tr>
                                        <th>#</th>

                                        <th>Título</th>
                                    </tr>
                                </thead>

                                <tbody >{
                                    this.state.lista.map(function(tipoevento){
                                        return(
                                            <tr key={tipoevento.id}>
                                                <td>{tipoevento.id}</td>
                                                <td>{tipoevento.nome}</td>
                                            </tr>
                                        );
                                    })
                                }
                                </tbody>
                            </table>
                        </div>
                        <Titulo mensagem="Cadastrar Tipo Evento" />
                            
                        <div className="container" id="conteudoPrincipal-cadastro">
                           
                            <form onSubmit={this.CadastrarTipoEvento.bind(this)}>
                                <div className="container">
                                    <input
                                        type="text"
                                        value={this.state.nome}
                                        onChange={this.atualizaEstadoNomeForm}
                                        id="nome-tipo-evento"
                                        placeholder="tipo do evento"
                                    />
                                    <button
                                        className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro"
                                    >
                                        Cadastrar
                      </button>
                                </div>
                            </form>
                        </div>
                    </section>
                </main>

                <Rodape />
            </div>

        )
    }
}
export default TiposEventos;