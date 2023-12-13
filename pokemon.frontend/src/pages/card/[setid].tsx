import React from "react";
import { getCardsBySet } from "@/services/pokemonCardService";
import { getAllSets } from "@/services/pokemonSetService";
import { QueryClient, dehydrate, useQuery } from "@tanstack/react-query";
import LoadingComponent from "@/components/Common/LoadingComponent/LoadingComponent";
import HeaderComponent from "@/components/HeaderComponent/HeaderComponent";
import AntCard3Component from "@/components/CardComponent/AntCardComponent/AntCard3Component";
import { Col, Flex, Row } from "antd";
import { QueryKeys } from "@/utilities/reactQuery/queryKeys";
import { useRouter } from "next/router";
import { GetStaticPaths, GetStaticPathsContext, GetStaticProps, GetStaticPropsContext } from "next/types";

export const getStaticPaths: GetStaticPaths = async (qry: GetStaticPathsContext) => {
  const resultSets = await getAllSets();
  if (!resultSets.isSuccess) return { paths: [], fallback: true };

  const sets = resultSets.data!;
  const setIds = sets.map(set => ({ params: { setid: set.id } }));

  return { paths: setIds, fallback: true };
};

export const getStaticProps: GetStaticProps = async (context: GetStaticPropsContext) => {
    const setId = context.params!.setid as string;

    const queryClient = new QueryClient();
    await queryClient.fetchQuery({
        queryKey: [QueryKeys.GetACard, setId],
        queryFn: async () => {
            const resultCards = await getCardsBySet(setId);
            if(!resultCards.isSuccess) return [];
            return resultCards.data!;
        }
    });

    return { props: { dehydratedState:  dehydrate(queryClient) }, revalidate: 24 * 60 * 60 }
}

const Index = () => {
  const router = useRouter();
  const setId = router.query.setid as string;

  const {data} = useQuery({
    queryKey: [QueryKeys.GetACard, setId],
    queryFn: async () => {
      const resultCards = await getCardsBySet(setId);
      if (!resultCards.isSuccess) return [];
      return resultCards.data!;
    },
    enabled: (setId !== undefined),
    refetchOnMount: false,
    retryOnMount: false,
    refetchOnWindowFocus: false,
    retry: false
  });

  if(!data) return <LoadingComponent />;

  return (
    <>
      <HeaderComponent />
      <Flex justify='center' className='border-2'>
        <Row gutter={[20, 20]} className='wrapper'>
          {
            data.map(item => (
              <Col xs={24} sm={12}  key={item.id}>
                <AntCard3Component item={item}/>
              </Col>
            ))
          }
        </Row>
      </Flex>
    </>
  )
};

export default Index;
