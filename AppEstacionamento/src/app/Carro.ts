import { Modelo } from "./Modelo";

export class Carro {
    placa: string = '';
    modeloId: number = 0;
    modelo: Modelo | undefined;
    descricao: string = '';
}