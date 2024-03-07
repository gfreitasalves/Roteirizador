import axios from 'axios';
import { Viagem } from '../models/Viagem';

// Armazenando o endereço da API
const apiUrl = "https://localhost:5142"

const CalcularRotaService = {    

    async calcular(origem: string, destino: string) {
        const enpoint = apiUrl + "/calcularRota"
        const result = (await axios.post<Viagem>(enpoint, { origem: origem, destino: destino })).data
        console.log(result)
        return result
    }
}

export default CalcularRotaService;