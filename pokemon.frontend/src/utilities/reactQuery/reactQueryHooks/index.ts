import { QueryKeys } from "../queryKeys";
import { UseQueryResult, useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { getAllSets, getSetById, toDesceding } from "./../../../services/pokemonSetService";
import { ISet, IterableList } from "@/types";

export const useGetAllSet = (): UseQueryResult<ISet[], Error> => {
  return useQuery<ISet[], Error>({
    queryKey: [QueryKeys.GetAllSet],
    queryFn: async () => {
      const result = await getAllSets();

      if (result.isSuccess) {
        const sets = result.data!;
        toDesceding(sets);

        return sets;
      }

      return result.data!;
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
