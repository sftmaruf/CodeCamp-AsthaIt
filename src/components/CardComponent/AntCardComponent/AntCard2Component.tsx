import { FunctionComponent } from "react";
import { useGetASet } from "@/utilities/reactQuery/reactQueryHooks";
import Image from 'next/image';
import { Button, Col, Row } from "antd";
import RemoveButton from "@/components/Common/ButtonComponent/RemoveButton";
import { useApplicationStore } from "@/stores/applicationStore";
import { ISetExtended } from "@/types";

const AntCard2Component: FunctionComponent<{_item: ISetExtended}> = ({_item}) => {
  // const [value, setValue] = useState(0);
  const removeFromCart = useApplicationStore(state => state.removeFromCart);

  // const set = useGetASet(_id);
  // if(!set.data) return <div>Loading</div>

  return (
      <Row align='middle' className="shadow-md rounded h-[100px] p-4">
        <Col sm={9} className='hidden md:block w-[100px] relative text-center h-full px-4'>
          <Image src={`${_item.images.logo}`} alt={`image-${_item.name}`} className='object-contain' fill />
        </Col>
        <Col xs={22} md={13} className='text-center'>{_item.name}</Col>
        <Col xs={2} md={2} className='text-center'>
          <Button onClick={() => removeFromCart(_item)} shape='circle' size='small' type="primary" danger icon={<RemoveButton />}/>
        </Col>
      </Row>
  );
};

export default AntCard2Component;