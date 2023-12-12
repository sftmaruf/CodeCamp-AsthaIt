import { getCardsBySet } from "@/services/pokemonCardService";
import { getAllSets } from "@/services/pokemonSetService";
import { GetStaticPaths, GetStaticPathsContext, GetStaticProps, GetStaticPropsContext } from "next";
import React from "react";
import { QueryClient, dehydrate, useQuery } from "@tanstack/react-query";
import LoadingComponent from "@/components/Common/LoadingComponent/LoadingComponent";
import HeaderComponent from "@/components/HeaderComponent/HeaderComponent";
import AntCard3Component from "@/components/CardComponent/AntCardComponent/AntCard3Component";
import { Col, Flex, Row } from "antd";
import { QueryKeys } from "@/utilities/reactQuery/queryKeys";

export const getStaticPaths: GetStaticPaths = async (qry: GetStaticPathsContext) => {
  const resultSets = await getAllSets();
  if (!resultSets.isSuccess) return { paths: [], fallback: true };

  const sets = resultSets.data!;
  const setIds = sets.map(set => ({ params: { setid: set.id } }));

  return { paths: setIds.slice(0, 5), fallback: true };
};

export const getStaticProps: GetStaticProps = async (context: GetStaticPropsContext) => {
    const setId = context.params!.setid as string;

    const queryClient = new QueryClient();
    await queryClient.fetchQuery({
        queryKey: [QueryKeys.GetASet],
        queryFn: async () => {
            const resultCards = await getCardsBySet(setId);
            if(!resultCards.isSuccess) return [];
            return resultCards.data!;
        }
    });

    return { props: { dehydratedState:  dehydrate(queryClient) } }
}

const Index = () => {
  const { data } = useQuery({
    queryKey: [QueryKeys.GetASet],
    queryFn: async () => {
      const resultCards = await getCardsBySet("base2");
      if (!resultCards.isSuccess) return [];
      return resultCards.data!;
    },
    enabled: true,
  });

  if(!data || data?.length === 0) return <LoadingComponent />;

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
