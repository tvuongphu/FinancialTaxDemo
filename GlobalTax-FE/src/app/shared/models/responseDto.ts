interface TaxBreakdown {
  range: string;
  rate: number;
  taxedAmount: number;
  taxOwed: number;
}

interface TaxResult {
  totalTax: number;
  effectiveRate: number;
  breakdown: TaxBreakdown[];
}
 
interface TaxBracketDetail {
  // id: number;
  level: number;
  limit: number;
  rate: number;
  // countryCode: string;
}

interface ValidationResponseDto {
  success: boolean;
  response: string[];
}

interface UpdateBracketResponseDto {
  success: boolean;
  response: string;
}

interface GetTaxBracketResponseDto {
  success: boolean;
  response: string;
  brackets: TaxBracketDetail[];
}


//

interface Country {
  // id: number;
  countryCode: string;
  countryName: string;
}


interface GetCountryResponseDto {
  success: boolean;
  country: Country[];
}

export type { 
  TaxBreakdown, 
  TaxResult, 
  TaxBracketDetail,
  ValidationResponseDto,
  UpdateBracketResponseDto,
  GetTaxBracketResponseDto,
  GetCountryResponseDto,
  Country
};