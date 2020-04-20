using Unity.Mathematics;
using Unity.Collections;

namespace LinearBlur
{

	public struct ColorArrayJob : Unity.Jobs.IJob
	{
		NativeArray<float4> source, blurred;//float4 is simd, Color isn't, hence in/out conversions (trading memory for speed here)
		int width, height, boxSize, iterations, radius;
		public ColorArrayJob ( UnityEngine.Color[] source , int width , int height , int radius , int iterations )
		{
			this.source = new NativeArray<float4>( source.Length , Allocator.TempJob , NativeArrayOptions.UninitializedMemory );
			for( int i=source.Length-1 ; i!=-1 ; i-- )
			{
				var col = source[ i ];
				this.source[ i ] = new float4{ x=col.r , y=col.g , z=col.b , w=col.a };
			}
			this.blurred = new NativeArray<float4>( this.source , Allocator.TempJob );
			this.radius = radius;
			this.boxSize = radius * 2 + 1;
			this.width = width;
			this.height = height;
			this.iterations = iterations;
		}
		void Unity.Jobs.IJob.Execute ()
		{
			for( int iteration=0 ; iteration<iterations ; iteration++ )
			{
				// horizontal blur:
				blurred.CopyTo( source );
				for( int Y=0 ; Y<height ; ++Y )
				{
					float4 sum = default(float4);
					{
						for( int x=-radius ; x<=radius ; ++x ) sum += GET.VALUE( source , x , Y , width , height );
						blurred[ GET.INDEX(0,Y,width) ] = sum/boxSize;
					}
					for( int X=1 ; X<width ; X++ )
					{
						sum -= GET.VALUE( source , X-radius-1 , Y , width , height );
						sum += GET.VALUE( source , X + radius , Y , width , height );
						blurred[ GET.INDEX(X,Y,width) ] = sum/boxSize;
					}
				}
				// vertical blur:
				blurred.CopyTo( source );
				for( int X=0 ; X<width ; X++ )
				{
					float4 sum = default(float4);
					{
						for( int y=-radius ; y<=radius ; ++y ) sum += GET.VALUE( source , X , y , width , height );
						blurred[ GET.INDEX(X,0,width) ] = sum/boxSize;
					}
					for( int Y=1 ; Y<height ; ++Y )
					{
						sum -= GET.VALUE( source , X , Y-radius-1 , width , height );
						sum += GET.VALUE( source , X , Y+radius , width , height );
						blurred[ GET.INDEX(X,Y,width) ] = sum/boxSize;
					}
				}
			}
		}
		public UnityEngine.Color[] GetResultsAndClose ()
		{
			UnityEngine.Color[] results = new UnityEngine.Color[ blurred.Length ];
			for( int i=blurred.Length-1 ; i!=-1 ; i-- )
			{
				var f4 = blurred[ i ];
				results[ i ] = new UnityEngine.Color{ r=f4.x , g=f4.y , b=f4.z , a=f4.w };
			}
			source.Dispose();
			blurred.Dispose();
			return results;
		}
	}

	/// <summary>
	/// Blurs TextureFormat.R16 textures.
	/// Get data calling texture.GetRawTextureData<ushort>(). Call texture.Apply() when job is completed to send changes to GPU.
	/// </summary>
	public struct NativeR16Job : Unity.Jobs.IJob, System.IDisposable
	{
		NativeArray<ushort> results, copy;
		readonly int width, height, boxSize, iterations, radius;
		public NativeR16Job ( NativeArray<ushort> rawData , int width , int height , int radius , int iterations )
		{
			this.results = rawData;
			this.copy = new NativeArray<ushort>( rawData , Allocator.TempJob );
			this.radius = radius;
			this.boxSize = radius * 2 + 1;
			this.width = width;
			this.height = height;
			this.iterations = iterations;
		}
		void Unity.Jobs.IJob.Execute ()
		{
			for( int iteration=0 ; iteration<iterations ; iteration++ )
			{
				// horizontal blur:
				copy.CopyTo( results );
				for( int Y=0 ; Y<height ; ++Y )
				{
					ushort sum = default(ushort);
					{
						for( int x=-radius ; x<=radius ; ++x ) sum += GET.VALUE( results , x , Y , width , height );
						copy[ GET.INDEX(0,Y,width) ] = (ushort)( sum/boxSize );
					}
					for( int X=0 ; X<width ; X++ )
					{
						sum -= GET.VALUE( results , X-radius-1 , Y , width , height );
						sum += GET.VALUE( results , X + radius , Y , width , height );
						copy[ GET.INDEX(X,Y,width) ] = (ushort)( sum/boxSize );
					}
				}
				// vertical blur:
				copy.CopyTo( results );
				for( int X=0 ; X<width ; X++ )
				{
					ushort sum = default(ushort);
					{
						for( int y=-radius ; y<=radius ; ++y ) sum += GET.VALUE( results , X , y , width , height );
						copy[ GET.INDEX(X,0,width) ] = (ushort)( sum/boxSize );
					}
					for( int Y=0 ; Y<height ; ++Y )
					{
						sum -= GET.VALUE( results , X , Y-radius-1 , width , height );
						sum += GET.VALUE( results , X , Y+radius , width , height );
						copy[ GET.INDEX(X,Y,width) ] = (ushort)( sum/boxSize );
					}
				}
			}
		}
		public void Close () => Dispose();
		public void Dispose () => copy.Dispose();
	}
	
	/// <summary>
	/// Blurs TextureFormat.RGB24 textures.
	/// Get data calling texture.GetRawTextureData<RGB24>(). Call texture.Apply() when job is completed to send changes to GPU.
	/// </summary>
	public struct NativeRGB24Job : Unity.Jobs.IJob, System.IDisposable
	{
		NativeArray<RGB24> results , copy;
		readonly int width, height, boxSize, iterations, radius;
		public NativeRGB24Job ( NativeArray<RGB24> rawData , int width , int height , int radius , int iterations )
		{
			this.results = rawData;
			this.copy = new NativeArray<RGB24>( rawData , Allocator.TempJob );
			this.radius = radius;
			this.boxSize = radius * 2 + 1;
			this.width = width;
			this.height = height;
			this.iterations = iterations;
		}
		void Unity.Jobs.IJob.Execute ()
		{
			for( int iteration=0 ; iteration<iterations ; iteration++ )
			{
				// horizontal blur:
				copy.CopyTo( results );
				for( int Y=0 ; Y<height ; ++Y )
				{
					float3 sum = default(float3);
					{
						for( int x=-radius ; x<=radius ; ++x ) sum += GET.VALUE( results , x , Y , width , height );
						copy[ GET.INDEX(0,Y,width) ] = sum/boxSize;
					}
					for( int X=0 ; X<width ; X++ )
					{
						sum -= GET.VALUE( results , X-radius-1 , Y , width , height );
						sum += GET.VALUE( results , X + radius , Y , width , height );
						copy[ GET.INDEX(X,Y,width) ] = sum/boxSize;
					}
				}
				// vertical blur:
				copy.CopyTo( results );
				for( int X=0 ; X<width ; X++ )
				{
					float3 sum = default(float3);
					{
						for( int y=-radius ; y<=radius ; ++y ) sum += GET.VALUE( results , X , y , width , height );
						copy[ GET.INDEX(X,0,width) ] = sum/boxSize;
					}
					for( int Y=0 ; Y<height ; ++Y )
					{
						sum -= GET.VALUE( results , X , Y-radius-1 , width , height );
						sum += GET.VALUE( results , X , Y+radius , width , height );
						copy[ GET.INDEX(X,Y,width) ] = sum/boxSize;
					}
				}
			}
		}
		public void Close () => Dispose();
		public void Dispose () => copy.Dispose();
	}
	
	/// <summary>
	/// Blurs TextureFormat.RGBA32 textures.
	/// Get data calling texture.GetRawTextureData<RGBA32>(). Call texture.Apply() when job is completed to send changes to GPU.
	/// </summary>
	public struct NativeRGBA32Job : Unity.Jobs.IJob, System.IDisposable
	{
		NativeArray<RGBA32> results , copy;
		readonly int width, height, boxSize, iterations, radius;
		public NativeRGBA32Job ( NativeArray<RGBA32> rawData , int width , int height , int radius , int iterations )
		{
			this.results = rawData;
			this.copy = new NativeArray<RGBA32>( rawData , Allocator.TempJob );
			this.radius = radius;
			this.boxSize = radius * 2 + 1;
			this.width = width;
			this.height = height;
			this.iterations = iterations;
		}
		void Unity.Jobs.IJob.Execute ()
		{
			for( int iteration=0 ; iteration<iterations ; iteration++ )
			{
				// horizontal blur:
				copy.CopyTo( results );
				for( int Y=0 ; Y<height ; ++Y )
				{
					float4 sum = default(float4);
					{
						for( int x=-radius ; x<=radius ; ++x ) sum += GET.VALUE( results , x , Y , width , height );
						copy[ GET.INDEX(0,Y,width) ] = sum/boxSize;
					}
					for( int X=0 ; X<width ; X++ )
					{
						sum -= GET.VALUE( results , X-radius-1 , Y , width , height );
						sum += GET.VALUE( results , X + radius , Y , width , height );
						copy[ GET.INDEX(X,Y,width) ] = sum/boxSize;
					}
				}
				// vertical blur:
				copy.CopyTo( results );
				for( int X=0 ; X<width ; X++ )
				{
					float4 sum = default(float4);
					{
						for( int y=-radius ; y<=radius ; ++y ) sum += GET.VALUE( results , X , y , width , height );
						copy[ GET.INDEX(X,0,width) ] = sum/boxSize;
					}
					for( int Y=0 ; Y<height ; ++Y )
					{
						sum -= GET.VALUE( results , X , Y-radius-1 , width , height );
						sum += GET.VALUE( results , X , Y+radius , width , height );
						copy[ GET.INDEX(X,Y,width) ] = sum/boxSize;
					}
				}
			}
		}
		public void Close () => Dispose();
		public void Dispose () => copy.Dispose();
	}

	internal static class GET
	{
		
		/// <summary> Access array with xy clamped to safe values </summary>
		public static T VALUE <T> ( T[] array , int x , int y , int width , int height ) => array[ INDEX( math.clamp( x , 0 , width-1 ) , math.clamp( y , 0 , height-1 ) , width ) ];
		
		/// <summary> Access native array with xy clamped to safe values </summary>
		public static T VALUE <T> ( NativeArray<T> array , int x , int y , int width , int height ) where T : struct => array[ INDEX( math.clamp( x , 0 , width-1 ) , math.clamp( y , 0 , height-1 ) , width ) ];
		
		/// <summary> Calculates 1d index from x and y </summary>
		public static int INDEX ( int x , int y , int width ) => y * width + x;

	}

	public struct RGB24
	{
		public byte r, g, b;
		public static implicit operator float3 ( RGB24 rgb ) => new float3 { x = rgb.r , y = rgb.g , z = rgb.b };
		public static implicit operator RGB24 ( float3 f3 ) => new RGB24 { r = (byte)math.clamp(f3.x,0,255) , g = (byte)math.clamp(f3.y,0,255) , b = (byte)math.clamp(f3.z,0,255) };
	}
	
	public struct RGBA32
	{
		public byte r, g, b, a;
		public static implicit operator float4 ( RGBA32 rgba ) => new float4 { x = rgba.r , y = rgba.g , z = rgba.b , w = rgba.a };
		public static implicit operator RGBA32 ( float4 f4 ) => new RGBA32 { r = (byte)math.clamp(f4.x,0,255) , g = (byte)math.clamp(f4.y,0,255) , b = (byte)math.clamp(f4.z,0,255) , a = (byte)math.clamp(f4.w,0,255) };
	}

}