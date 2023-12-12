import { ICard, Result } from "@/types";
import { PokemonTCG } from "pokemon-tcg-sdk-typescript";
import { Parameter } from "pokemon-tcg-sdk-typescript/dist/sdk";
// import { Parameter } from 'pokemon-tcg-sdk-typescript/interfaces/parameter';

export const getCardsBySet = async (
  setId: string
): Promise<Result<ICard[]>> => {
  try {
    const filter: Parameter = { q: `set.id:${setId}`, pageSize: 5 };
    const c = await PokemonTCG.findCardsByQueries(filter);

    const cardsOfASpecificSet = c.filter((card) => card.set.id === setId);
    return { isSuccess: true, data: cardsOfASpecificSet, errors: [] };
  } catch (err) {
    return {
      isSuccess: false,
      data: undefined,
      errors: ["failed to fetch data"],
    };
  }
};
