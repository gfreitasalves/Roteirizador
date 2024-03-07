import axios from 'axios';
import { Rota } from '../models/Rota';

// Armazenando o endereço da API
const apiUrl = "https://localhost:5142"

const RotaService = {    
    async listar() {
        const enpoint = apiUrl + "/rota"
        return (await axios.get<Rota[]>(enpoint)).data
    },
        
    async obter(rotaId: string) {
        const enpoint = apiUrl + "/rota/" + rotaId
        return (await axios.get<Rota>(enpoint)).data
    },
        
    async criar(data: Rota) {
        const enpoint = apiUrl + "/rota"
        return (await axios.post<Rota>(enpoint, data)).data
    },
    
    async editar(data: Rota) {
        const enpoint = apiUrl + "/rota"
        return (await axios.put<Rota>(enpoint, data)).data
    },
        
    async deletar(rotaId: string) {
        const enpoint = apiUrl + "/rota/" + rotaId
        return (await axios.delete(enpoint)).data
    }
}

export default RotaService;