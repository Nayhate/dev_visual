import { Marca } from "./Marca";

export class Modelo {
    id: number = 0;
    marcaId: number = 0;
    marca: Marca | undefined;
    nome: string = '';
}