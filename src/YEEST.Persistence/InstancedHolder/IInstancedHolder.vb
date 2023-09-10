Public Interface IInstancedHolder
    Inherits IHolder
    ReadOnly Property Id As Integer
    ReadOnly Property World As IWorld
    Sub Recycle()
End Interface
