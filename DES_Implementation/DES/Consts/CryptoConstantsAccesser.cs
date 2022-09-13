using DES_Implementation.DES.Enums;

namespace DES_Implementation.DES.Consts
{
    public static class CryptoConstantsAccesser
    {
		public static int[,] GetSbox(int sboxes)
		{
			switch (sboxes)
			{
				case 0:
					return SBoxes.sbox1;
				case 1:
					return SBoxes.sbox2;
				case 2:
					return SBoxes.sbox3;
				case 3:
					return SBoxes.sbox4;
				case 4:
					return SBoxes.sbox5;
				case 5:
					return SBoxes.sbox6;
				case 6:
					return SBoxes.sbox7;
				case 7:
					return SBoxes.sbox8;
				default:
					throw new NotImplementedException();
			}
		}
		public static int[] GetPermutationConsts(Permutation probability)
		{
			switch (probability)
			{
				case Permutation.PC1:
					return PermutationConsts.PC1;
				case Permutation.PC2:
					return PermutationConsts.PC2;
				case Permutation.IP:
					return PermutationConsts.IP;
				case Permutation.IPInverse:
					return PermutationConsts.IPInverse;
				case Permutation.P:
					return PermutationConsts.P;
				case Permutation.EP:
					return PermutationConsts.EP;
				case Permutation.ShiftBits:
					return PermutationConsts.shiftBits;
				default:
					throw new NotImplementedException();
			}
		}
	}
}
