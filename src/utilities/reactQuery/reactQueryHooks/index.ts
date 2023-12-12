import { QueryKeys } from "../queryKeys";
import { UseQueryResult, useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { getAllSets, getSetById, toDesceding } from "./../../../services/pokemonSetService";
import { ISet, IterableList } from "@/types";
import { getItemFromLocalStorage } from "@/services/localStorageService";

export const useGetAllSet = (): UseQueryResult<IterableList[], Error> => {
  return useQuery<IterableList[], Error>({
    queryKey: [QueryKeys.GetAllSet],
    queryFn: async () => {
      const result = await getAllSets();
      let iterableList: IterableList[] = [];

      if (result.isSuccess) {
        const sets = result.data!;
        toDesceding(sets);
        iterableList = sets.map((set) => ({
          id: set.id,
          name: set.name,
          image: set.images.logo,
        }));

        return iterableList;
      }

      return iterableList;
    },
    enabled: true,
    refetchOnMount: false,
    retryOnMount: false,
    refetchOnWindowFocus: false,
    retry: 3
  });
};

export const useGetASet = (_id: string) => {
  return useQuery({
    queryKey: [QueryKeys.GetASet, _id],
    queryFn: async () => {
      const result = await getSetById(_id);

      if(result.isSuccess)
      {
        return result.data;
      }

      return result.data;
    },
    enabled: true,
    refetchOnMount: false,
    retryOnMount: false,
    refetchOnWindowFocus: false,
    retry: 3,
  });
}

export const useEditName = () => {
  const queryClient = useQueryClient();

  const editNameMutation = useMutation({
    mutationFn: ({
      setId,
      newName,
    }: {
      setId: string;
      newName: string;
    }): Promise<{ setId: string; newName: string }> =>
      new Promise((resolve) => resolve({ setId, newName })),
    onSuccess: (data: { setId: string; newName: string }) => {
      queryClient.setQueryData(
        [QueryKeys.GetASet, data.setId],
        (initialSet: ISet) => {
          initialSet.name = data.newName;
          return { ...initialSet };
        }
      );
    },
  });

  return editNameMutation;
}

// const usetName = () => {
//    return useMutation({
//     mutationFn: () => {  },
//     onSuccess: () => {}
//    })
// }

// export const useLocalStorage = () => {
//   return useQuery({
//     queryKey: [QueryKeys.GetASet],
//     queryFn: () => {
//       const result = getItemFromLocalStorage('count');
//       if(!result.isSuccess) ({ count: 0, itemIds: [] as string[] } as ICart);

//       const resultAsJson = JSON.parse(result.data!) as { cart: ICart };
//       return resultAsJson.cart;
//     }
//   })
// }