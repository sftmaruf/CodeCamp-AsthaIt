import HomeComponent from '@/components/HomeComponent/HomeComponent';
import { getAllSets, toDesceding } from '@/services/pokemonSetService';
import { IterableList } from '@/types';
import { GetServerSideProps, GetServerSidePropsContext, GetStaticProps, GetStaticPropsContext } from 'next/types';
import { FunctionComponent } from 'react';
import React from 'react';
import { QueryClient, dehydrate, useQuery } from '@tanstack/react-query';
import { QueryKeys } from '@/utilities/reactQuery/queryKeys';
import { useGetAllSet } from '@/utilities/reactQuery/reactQueryHooks';
import LoadingComponent from '@/components/Common/LoadingComponent/LoadingComponent';

export const getStaticProps: GetStaticProps = async(context: GetStaticPropsContext) => {
    const queryClient = new QueryClient();
    await queryClient.fetchQuery({
      queryKey: [QueryKeys.GetAllSet],
      queryFn: async () => {
        const result = await getAllSets();
        let iterableList: IterableList[] = [];

        if(result.isSuccess) {
            const sets = result.data!;
            toDesceding(sets);
            iterableList = sets.map(set => ({ id:set.id, name: set.name, image: set.images.logo }));
            return iterableList;
        }

        return iterableList;
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