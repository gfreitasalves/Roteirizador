import { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import { Rota } from '../../models/Rota';
import RotaService from '../../services/RotaService';
type FormControlElement = HTMLInputElement | HTMLTextAreaElement;
export default function NovaRota() {
    const [rota, setRota] = useState<Rota>(
        {            
            origem: '',
            destino: '',
            valor:  0
        }
    );
    
    const { origem, destino, valor } = rota;

    const navigate = useNavigate();

    const novaRotaHandler = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        
        await RotaService.criar(rota)

        navigate("/rota");
    }

    const handleInputChange = (event: React.ChangeEvent<FormControlElement>) => {
        const { name, value } = event.target;
        switch (name) {            
            case 'valor':
                if (value === '' || value.match(/^\d{1,}(\.\d{0,2})?$/)) {
                    setRota((prevState) => ({
                        ...prevState,
                        [name]: Number(value)
                    }));
                }
                break;
            default:
                setRota((prevState) => ({
                    ...prevState,
                    [name]: value
                }));
        }
    };

    return (
        <div className="main-form">
            <h3>Nova Rota</h3>
            <Form onSubmit={novaRotaHandler}>
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
                <Form.Group controlId="valor">
                    <Form.Label>Valor</Form.Label>
                    <Form.Control
                        className="input-control"
                        type="text"
                        name="valor"
                        value={valor}
                        placeholder="Valor"
                        onChange={handleInputChange}
                    />
                </Form.Group>
                <Button variant="primary" type="submit" className="submit-btn mt-5">
                    Salvar
                </Button>
                <Button variant="secondary" type="button" className="btn mt-5 ms-2 " onClick={()=> navigate("/rota")}>
                    Voltar
                </Button>
            </Form>
        </div>
    )
}
