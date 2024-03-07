import { useState } from "react";
import { Button, Form } from "react-bootstrap";
import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';
import { Viagem } from "../models/Viagem";
import { Rota } from "../models/Rota";
import CalcularRotaService from "../services/CalcularRotaService";
type FormControlElement = HTMLInputElement | HTMLTextAreaElement;

function CalcularRota() {
    const [rota, setRota] = useState(
        {
            origem: 'GRU',
            destino: 'CDG'
        }
    );

    const [viagem, setViagem] = useState<Viagem>(
        {
            origem: '',
            destino: '',
            valorTotal: 0,
            rotas: [],
            mensagem: '',
            sucesso: false
        }
    );

    const { origem, destino } = rota;

    const calcularRotaHandler = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        await CalcularRotaService.calcular(rota.origem, rota.destino)
            .then((data) => {  setViagem(data) })        
    }

    const handleInputChange = (event: React.ChangeEvent<FormControlElement>) => {
        const { name, value } = event.target;
        switch (name) {
            default:
                setRota((prevState) => ({
                    ...prevState,
                    [name]: value
                }));
        }
    };

    const ViagemResult = () => {
        if (viagem.sucesso) {
            return (
                <Card>
                    <Card.Header>Resultado</Card.Header>
                    <Card.Body>
                        <Card.Text>
                            <h4>Origem: {viagem.origem}</h4>
                            <h4>Destino: {viagem.destino}</h4>

                        </Card.Text>
                    </Card.Body>
                    <b>Rotas combinadas:</b>
                    <ListGroup className="list-group-flush">
                        {viagem.rotas.map((rota: Rota) => (
                            <ListGroup.Item>Origem: {rota.origem} Destino: {rota.destino} Valor: {rota.valor}</ListGroup.Item>
                        ))}
                    </ListGroup>
                    <h2 className="mt-2 text-primary">Total: {viagem.valorTotal}</h2>
                </Card>
            )
        }
        else if (viagem.origem!= '') {
            return (
                <Card>
                    <Card.Header>Resultado</Card.Header>
                    <Card.Body>
                        <Card.Text>
                            <h4>Origem: {viagem.origem}</h4>
                            <h4>Destino: {viagem.destino}</h4>

                        </Card.Text>
                    </Card.Body>
                    <b>{viagem.mensagem}</b>                    
                </Card>
            )
        }
    };

    return (
        <>

            <div className="container">
                <div className="row">
                    <div className="col-sm border-bottom">
                        <div className="m-5">
                            <h3>Calcular</h3>
                            <Form onSubmit={calcularRotaHandler}>
                                <Form.Group controlId="origem">
                                    <Form.Label>Origem</Form.Label>
                                    <Form.Control
                                        className="input-control"
                                        type="text"
                                        name="origem"
                                        value={origem}
                                        placeholder="Origem"
                                        onChange={handleInputChange}
                                    />
                                </Form.Group>
                                <Form.Group controlId="destino">
                                    <Form.Label>Destino</Form.Label>
                                    <Form.Control
                                        className="input-control"
                                        type="text"
                                        name="destino"
                                        value={destino}
                                        placeholder="Destino"
                                        onChange={handleInputChange}
                                    />
                                </Form.Group>
                                <Button variant="primary" type="submit" className="submit-btn mt-5">
                                    Calcular
                                </Button>
                            </Form></div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-sm mt-5">
                        <ViagemResult></ViagemResult>
                    </div>
                </div>
            </div>
        </>
    )
}

export default CalcularRota
