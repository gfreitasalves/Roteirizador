

export default function ListagemRota() {
    return (
        <>
            <button type="button" className="btn btn-dark mb-5 float-end rounded-5 bold" title="novo cliente"><i
                className="bi bi-plus"></i>Novo</button >

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

                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>
                            <div className="float-end">
                                <button type="button" className="btn btn-sm btn-primary me-1 rounded-5" title="editar cliente"
                                ><i className="bi bi-pencil"></i></button>
                                <button type="button" className="btn btn-sm btn-danger rounded-5" title="deletar cliente"
                                ><i className="bi bi-trash"></i></button>
                            </div>
                        </td>
                    </tr >

                </tbody >
            </table >
        </>
    )
}
