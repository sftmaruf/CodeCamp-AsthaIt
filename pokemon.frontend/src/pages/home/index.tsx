import React from 'react';
import HomeComponent from '@/components/HomeComponent/HomeComponent';
import { getAllSets, toDesceding } from '@/services/pokemonSetService';
import { GetStaticProps, GetStaticPropsContext } from 'next/types';
import { FunctionComponent } from 'react';
import { QueryClient, dehydrate } from '@tanstack/react-query';
import { QueryKeys } from '@/utilities/reactQuery/queryKeys';
import { useGetAllSet } from '@/utilities/reactQuery/reactQueryHooks';
import LoadingComponent from '@/components/Common/LoadingComponent/LoadingComponent';

export const getStaticProps: GetStaticProps = async(context: GetStaticPropsContext) => {
    const queryClient = new QueryClient();
    await queryClient.prefetchQuery({
      queryKey: [QueryKeys.GetAllSet],
      queryFn: async () => {
        const result = await getAllSets();

        if(result.isSuccess) {
            const sets = result.data!;
            toDesceding(sets);
            return sets;
        }

        return result.data;
      }
    });

    return { props: { dehydratedState: dehydrate(queryClient) }, revalidate: 24 * 60 * 60 };
}

const Index: FunctionComponent = () => {
    const state = useGetAllSet();

    if(!state.data) return <LoadingComponent />;

    return (
        <HomeComponent _sets={state.data} />
    );
};

export default Index;