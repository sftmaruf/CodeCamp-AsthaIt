import { useEditName, useGetASet } from "@/utilities/reactQuery/reactQueryHooks";
import { Button, Modal } from "antd";
import { useApplicationStore } from "@/stores/applicationStore";
import React, {
  FunctionComponent,
  Dispatch,
  SetStateAction,
  useState,
} from "react";
import SetDetails from "@/components/SetDetailsComponent/SetDetailsComponent";
import EditModal from "../EditModalComponent/EditModalComponent";

interface PropsType {
  modalOpen: boolean;
  setModalOpen: Dispatch<SetStateAction<boolean>>;
  _id: string;
}

const AddToCartModal: FunctionComponent<PropsType> = ({
  modalOpen,
  setModalOpen,
  _id,
}) => {
  const addToCart = useApplicationStore((state) => state.addToCart);
  const [editModalOpen, setEditModalOpen] = useState(false);

  const { data, isFetched } = useGetASet(_id);
  console.log(data);

  const handleEdit = () => {
    setEditModalOpen(!editModalOpen);
    // setModalOpen(false);
  };

  const { mutate: editName } =  useEditName();

  const handleUpdate = (newName: string) => {
    editName({setId: _id, newName: newName});
  };

  return (
    <>
      <Modal
        centered
        title={`${data?.name}`}
        open={modalOpen}
        okText="Add To Cart"
        okButtonProps={{ className: "bg-black" }}
        onOk={() => addToCart({ ...data!, timeStamp: Date.now() })}
        onCancel={() => setModalOpen(false)}
        footer={(_, { OkBtn, CancelBtn }) => (
          <>
            <Button onClick={() => handleEdit()}>Edit</Button>
            <CancelBtn />
            <OkBtn />
          </>
        )}>
        {!isFetched ? <div>Loading</div> : <SetDetails _data={data!} />}
      </Modal>

      <EditModal modalOpen={editModalOpen} setModalOpen={setEditModalOpen} setId={_id} handleUpdate={handleUpdate} />
    </>
  );
};

export default AddToCartModal;

// id: string;
// name: string;
// series: string;
// printedTotal: number;
// total: number;
// legalities: ILegality;
// ptcgoCode: string;
// releaseDate: string;
// updatedAt: string;
// images: SetImage;
