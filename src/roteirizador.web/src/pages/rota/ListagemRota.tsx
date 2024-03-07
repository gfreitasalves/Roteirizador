import { useEffect, useState } from "react"
import RotaService from "../../services/RotaService"
import { Rota } from "../../models/Rota"
import { useNavigate } from "react-router-dom";



export default function ListagemRota() {
    const navigate = useNavigate();
    const [rotas, setRotas] = useState<Rota[]>([])

    const getList = async () => {
        await RotaService.listar()
            .then(data => {
                setRotas(data)
            })
    }

    const deleteRota = async (id: string) => {
        console.log(id)
        await RotaService.deletar(id)
            .then(() => {
                getList()
            })
    }

    useEffect(() => { getList() }, [])
    return (
        <>
            <button type="button" className="btn btn-dark mb-5 float-end rounded-5 bold" title="nova rota" onClick={() => { navigate("/rota/nova") }}><i
                className="bi bi-plus"></i>Adicionar</button >

            <table className="table table-striped">
                <thead className="table-primary">
                    <tr>
                        <th scope="col">Origem</th>
                        <th scope="col">Destino</th>
                        <th scope="col">Valor</th>
                        <th scope="col"></th>
                    </tr >
                </thead >
                <tbody>

                    {rotas.map((rota: Rota) => (
                        <tr key={rota.id}>
                            <td>{rota.origem}</td>
                            <td>{rota.destino}</td>
                            <td>{rota.valor}</td>
                            <td>
                                <div className="float-end">
                                    <button type="button" className="btn btn-sm btn-primary me-1 rounded-5" title="editar rota" onClick={() => { navigate("/rota/" + rota.id) }}
                                    ><i className="bi bi-pencil"></i></button>
                                    <button type="button" className="btn btn-sm btn-danger rounded-5" title="deletar rota" onClick={() => { deleteRota(rota.id as string) }}
                                    ><i className="bi bi-trash"></i></button>
                                </div>
                            </td>
                        </tr >
                    ))}
                </tbody >
            </table >
        </>
    )

}
