using DES_Implementation.DES.Enums;

namespace DES_Implementation.DES.Consts
{
    public static class CryptoConsts
	{
		public static int[,] GetSboxConst(int sboxes)
		{
			return CryptoConstantsAccesser.GetSbox(sboxes);
		}
		public static int[] GetConsts(Permutation probability)
		{
			return CryptoConstantsAccesser.GetPermutationConsts(probability);
		}
	}

}
