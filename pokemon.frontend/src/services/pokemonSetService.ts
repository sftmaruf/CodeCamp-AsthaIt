import { ISet, Result } from '@/types';
import { convertStringToDate } from '@/utilities';
import { PokemonTCG } from 'pokemon-tcg-sdk-typescript'
import { Set } from 'pokemon-tcg-sdk-typescript/dist/sdk';

export const getAllSets = async (): Promise<Result<ISet[]>> => {
    try {
        const sets = await PokemonTCG.getAllSets();
        return { isSuccess: true, data: sets, errors: [] }
    }
    catch (err)
    {
      return { isSuccess: false, data: [], errors: ['failed to fetch data'] }
    }
}

export const getSetById = async (_id: string): Promise<Result<Set>> => {
  try {
      const set = await PokemonTCG.findSetByID(_id);
      return { isSuccess: true, data: set, errors: [] }
  }
  catch (err)
  {
    return { isSuccess: false, data: undefined, errors: ['failed to fetch data'] }
  }
}

export const toDesceding = (_sets: Set[]): void  => {
    _sets.sort((a, b) => convertStringToDate(b.releaseDate).getTime() - convertStringToDate(a.releaseDate).getTime());
}