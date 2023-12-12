import { Card, Set } from "pokemon-tcg-sdk-typescript/dist/sdk";

export interface IterableList {
    id: string;
    name: string;
    image?: string
}

export interface Result<T> {
    isSuccess: boolean;
    data?: T;
    errors: string[];
}

export interface ICart {
    count: number;
    items: ISetExtended[];
  }

export type ISet = Set;
export type ISetExtended = ISet & { timeStamp: number };
export type ICard = Card;