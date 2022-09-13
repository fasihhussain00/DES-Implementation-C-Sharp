using DES_Implementation.DES.Consts;
using DES_Implementation.DES.Enums;

namespace DES_Implementation.DES.Helpers
{
    public class CryptoExtensions
    {
        private static string HexaDecimalToBinary(string Hex)
        {
            return string.Join(string.Empty, Hex.Select(c => Convert.ToString(Convert.ToInt64(c.ToString(), 16), 2).PadLeft(4, '0')));
        }
        private static string BinaryToHexDecimal(string Input)
        {
            int rest = Input.Length % 4;
            if (rest != 0)
                Input = new string('0', 4 - rest) + Input; 
            string output = string.Empty;
            for (int i = 0; i <= Input.Length - 4; i += 4)
                output += string.Format("{0:X}", Convert.ToByte(Input.Substring(i, 4), 2));
            return output;
        }
        protected static string ApplyPermutation(int[] PermutationSequence, string Input)
        {
            string output = string.Empty;
            Input = HexaDecimalToBinary(Input);
            for (int i = 0; i < PermutationSequence.Length; i++)
                output += Input[PermutationSequence[i] - 1];
            output = BinaryToHexDecimal(output);
            return output;
        }

        private static string PerformXOR(string FirstBits, string SecondBits)
        {
            ulong FirstBitsInLong = Convert.ToUInt64(FirstBits, 16);
            ulong SecondBitsInLong = Convert.ToUInt64(SecondBits, 16);
            FirstBitsInLong ^= SecondBitsInLong;
            FirstBits = string.Format("{0:X}", FirstBitsInLong);
            while (FirstBits.Length < SecondBits.Length)
                FirstBits = "0" + FirstBits;
            return FirstBits;
        }

        private static string LeftCircularShift(string Input, int NumberOfTimesApplyShifting)
        {
            int n = Input.Length * 4;
            int[] Permutation = new int[n];
            for (int i = 0; i < n - 1; i++)
                Permutation[i] = (i + 2);
            Permutation[n - 1] = 1;
            while (NumberOfTimesApplyShifting-- > 0)
                Input = ApplyPermutation(Permutation, Input);
            return Input;
        }

        protected static string[] GetAllKeys(string InitialKey)
        {
            string CurrentKey = InitialKey;
            string[] keys = new string[16];
            CurrentKey = ApplyPermutation(CryptoConsts.GetConsts(Permutation.PC1), CurrentKey);
            var ShiftBits = CryptoConsts.GetConsts(Permutation.ShiftBits);
            for (int i = 0; i < 16; i++)
            {
                CurrentKey = LeftCircularShift(CurrentKey[0..7], ShiftBits[i]) + LeftCircularShift(CurrentKey[7..14], ShiftBits[i]);
                keys[i] = ApplyPermutation(CryptoConsts.GetConsts(Permutation.PC2), CurrentKey);
            }
            return keys;
        }

        private static string ApplySbox(string Input)
        {
            string output = string.Empty;
            Input = HexaDecimalToBinary(Input);
            for (int i = 0; i < 48; i += 6)
            {
                string EachSixBitsFromInput = Input[i..(i + 6)];
                int num = i / 6;
                int row = Convert.ToInt32($"{EachSixBitsFromInput[0]}{EachSixBitsFromInput[5]}", 2);
                int col = Convert.ToInt32(EachSixBitsFromInput[1..5], 2);
                output += CryptoConsts.GetSboxConst(num)[row,col].ToString("X");
            }
            return output;
        }

        protected static string ApplyFunction(string Input, string Key)
        {
            string left = Input[0..8];
            string right = Input[8..16]; 
            string tempRight = right;

            var EP = CryptoConsts.GetConsts(Permutation.EP);
            var P = CryptoConsts.GetConsts(Permutation.P);

            tempRight = ApplyPermutation(EP, tempRight);
            tempRight = PerformXOR(tempRight, Key);
            tempRight = ApplySbox(tempRight);
            tempRight = ApplyPermutation(P, tempRight);
            left = PerformXOR(left, tempRight);

            return right + left;
        }
    }
}
