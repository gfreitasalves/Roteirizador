import { Rota } from "./Rota"

export type Viagem = {
    origem: string
    destino: string
    valorTotal: number
    rotas: Rota[]
    mensagem: string
    sucesso: boolean
}